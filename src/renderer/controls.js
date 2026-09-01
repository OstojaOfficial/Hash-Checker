'use strict';

function formatBytes(bytes) {
  const units = ['B', 'KB', 'MB', 'GB', 'TB'];
  let value = bytes;
  let unit = 0;
  while (value >= 1024 && unit < units.length - 1) {
    value /= 1024;
    unit += 1;
  }
  return `${unit === 0 ? Math.round(value) : value.toFixed(1)} ${units[unit]}`;
}

function fillAlgorithms(select) {
  algorithms.forEach((entry) => select.add(new Option(entry.name)));
}

function chosenAlgorithm(select) {
  return algorithms[select.selectedIndex];
}

function pathSelector(root, onChange) {
  const input = root.querySelector('input');
  const browse = root.querySelector('button');

  const assign = (value) => {
    input.value = value;
    onChange();
  };

  browse.addEventListener('click', async () => {
    const chosen = await api.chooseFile();
    if (chosen) assign(chosen);
  });

  input.addEventListener('input', onChange);

  root.addEventListener('dragover', (event) => {
    event.preventDefault();
    root.classList.add('is-drop-target');
  });
  root.addEventListener('dragleave', () => root.classList.remove('is-drop-target'));
  root.addEventListener('drop', (event) => {
    event.preventDefault();
    root.classList.remove('is-drop-target');

    const [file] = event.dataTransfer.files;
    if (file) assign(api.pathForFile(file));
  });

  return {
    get path() { return input.value.trim(); },
    set enabled(value) { input.disabled = !value; browse.disabled = !value; },
  };
}

window.addEventListener('dragover', (event) => event.preventDefault());
window.addEventListener('drop', (event) => event.preventDefault());

for (const tab of document.querySelectorAll('.tab')) {
  tab.addEventListener('click', () => {
    for (const other of document.querySelectorAll('.tab')) {
      other.classList.toggle('is-active', other === tab);
    }
    for (const panel of document.querySelectorAll('.panel')) {
      panel.classList.toggle('is-active', panel.id === `panel-${tab.dataset.panel}`);
    }
  });
}
