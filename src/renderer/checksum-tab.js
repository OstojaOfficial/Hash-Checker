'use strict';

function setupChecksumTab() {
  const algorithm = document.getElementById('single-algorithm');
  const action = document.getElementById('single-action');
  const progress = document.getElementById('single-progress');
  const result = document.getElementById('single-result');
  const copy = document.getElementById('single-copy');
  const status = document.getElementById('single-status');

  let job = null;

  const say = (message, isError = false) => {
    status.textContent = message;
    status.classList.toggle('is-error', isError);
  };

  const clearResult = () => {
    if (job) return;
    result.value = '';
    copy.disabled = true;
    say('');
  };

  const file = pathSelector(document.getElementById('single-picker'), clearResult);
  fillAlgorithms(algorithm);
  algorithm.addEventListener('change', clearResult);

  const setBusy = (busy) => {
    action.textContent = busy ? 'Cancel' : 'Compute';
    progress.hidden = !busy;
    progress.value = 0;
    file.enabled = !busy;
    algorithm.disabled = busy;
  };

  action.addEventListener('click', async () => {
    if (job) {
      job.cancel();
      return;
    }

    if (!file.path) {
      say('Choose a file first.', true);
      return;
    }

    clearResult();
    setBusy(true);

    job = startHash(file.path, chosenAlgorithm(algorithm).id, (percent) => {
      progress.value = percent;
    });

    const outcome = await job.done;
    job = null;
    setBusy(false);

    if (!outcome.ok) {
      say(outcome.message, true);
      return;
    }

    result.value = outcome.hex;
    copy.disabled = false;

    const size = formatBytes(outcome.bytesRead);
    const seconds = outcome.milliseconds / 1000;
    say(seconds > 0.05
      ? `Hashed ${size} in ${seconds.toFixed(2)} s (${formatBytes(outcome.bytesRead / seconds)}/s).`
      : `Hashed ${size}.`);
  });

  copy.addEventListener('click', () => {
    api.copyText(result.value);
    say('Copied to clipboard.');
  });
}

setupChecksumTab();
