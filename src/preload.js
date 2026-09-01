'use strict';

const { contextBridge, ipcRenderer, webUtils } = require('electron');

contextBridge.exposeInMainWorld('hashChecker', {
  chooseFile: () => ipcRenderer.invoke('choose-file'),

  hashFile: (jobId, filePath, algorithmId) =>
    ipcRenderer.invoke('hash-file', jobId, filePath, algorithmId),

  cancelHash: (jobId) => ipcRenderer.send('cancel-hash', jobId),
  copyText: (text) => ipcRenderer.send('copy-text', text),

  onProgress: (callback) => {
    ipcRenderer.on('hash-progress', (_event, jobId, percent) => callback(jobId, percent));
  },

  pathForFile: (file) => webUtils.getPathForFile(file),
});
