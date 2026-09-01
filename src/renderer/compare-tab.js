'use strict';

function setupCompareTab() {
  const algorithm = document.getElementById('compare-algorithm');
  const action = document.getElementById('compare-action');
  const progress = document.getElementById('compare-progress');
  const verdict = document.getElementById('verdict');
  const firstDigest = document.getElementById('first-digest');
  const secondDigest = document.getElementById('second-digest');
  const expected = document.getElementById('expected-hash');
  const secondPicker = document.getElementById('second-picker');
  const modes = document.querySelectorAll('input[name="mode"]');

  let job = null;

  const comparingTwoFiles = () =>
    document.querySelector('input[name="mode"]:checked').value === 'files';

  const clearResults = () => {
    if (job) return;
    verdict.hidden = true;
    firstDigest.textContent = '';
    secondDigest.textContent = '';
  };

  const first = pathSelector(document.getElementById('first-picker'), clearResults);
  const second = pathSelector(secondPicker, clearResults);
  fillAlgorithms(algorithm);
  algorithm.addEventListener('change', clearResults);

  for (const radio of modes) {
    radio.addEventListener('change', () => {
      const twoFiles = comparingTwoFiles();
      secondPicker.hidden = !twoFiles;
      expected.hidden = twoFiles;
      clearResults();
    });
  }

  expected.addEventListener('input', () => {
    clearResults();

    const normalized = normalizeHash(expected.value);
    if (!normalized) return;
    if (chosenAlgorithm(algorithm).hexLength === normalized.length) return;

    const detected = detectAlgorithm(normalized);
    if (detected >= 0) algorithm.selectedIndex = detected;
  });

  const show = (message, className) => {
    verdict.hidden = false;
    verdict.textContent = message;
    verdict.className = `verdict ${className}`;
  };

  const setBusy = (busy) => {
    action.textContent = busy ? 'Cancel' : 'Compare';
    progress.hidden = !busy;
    if (!busy) progress.value = 0;
    first.enabled = !busy;
    second.enabled = !busy;
    expected.disabled = busy;
    algorithm.disabled = busy;
    for (const radio of modes) radio.disabled = busy;
  };

  action.addEventListener('click', async () => {
    if (job) {
      job.cancel();
      return;
    }

    if (!first.path) {
      show('Choose the first file.', 'is-error');
      return;
    }

    let expectedDigest = '';
    if (comparingTwoFiles()) {
      if (!second.path) {
        show('Choose the second file.', 'is-error');
        return;
      }
    } else {
      expectedDigest = normalizeHash(expected.value);
      if (!expectedDigest) {
        show('Paste a checksum to compare against (hex characters only).', 'is-error');
        return;
      }
    }

    clearResults();
    setBusy(true);

    const algorithmId = chosenAlgorithm(algorithm).id;
    const twoFiles = comparingTwoFiles();

    try {
      job = startHash(first.path, algorithmId, (percent) => {
        progress.value = twoFiles ? percent / 2 : percent;
      });

      const a = await job.done;
      if (!a.ok) {
        show(a.message, 'is-error');
        return;
      }
      firstDigest.textContent = a.hex;

      if (twoFiles) {
        job = startHash(second.path, algorithmId, (percent) => {
          progress.value = 50 + percent / 2;
        });

        const b = await job.done;
        if (!b.ok) {
          show(b.message, 'is-error');
          return;
        }
        expectedDigest = b.hex;
      }

      secondDigest.textContent = expectedDigest;
      show(
        a.hex === expectedDigest
          ? 'MATCH'
          : 'NO MATCH',
        a.hex === expectedDigest ? 'is-match' : 'is-mismatch',
      );
    } finally {
      job = null;
      setBusy(false);
    }
  });
}

setupCompareTab();
