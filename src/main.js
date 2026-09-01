'use strict';

const { app, BrowserWindow, Menu, clipboard, dialog, ipcMain } = require('electron');
const path = require('node:path');

const { hashFile } = require('./hasher.js');

const jobs = new Map();

function createWindow() {
  const window = new BrowserWindow({
    width: 780,
    height: 500,
    minWidth: 620,
    show: false,
    webPreferences: {
      preload: path.join(__dirname, 'preload.js'),
      contextIsolation: true,
      nodeIntegration: false,
    },
  });

  window.loadFile(path.join(__dirname, 'renderer', 'index.html'));

  window.once('ready-to-show', () => window.show());
}

function describeError(error) {
  if (error.name === 'AbortError') return 'Cancelled.';

  switch (error.code) {
    case 'ENOENT': return 'Cannot open file: no such file or directory.';
    case 'EACCES': return 'Cannot open file: permission denied.';
    case 'EISDIR': return 'That is a folder, not a file.';
    default:       return error.message;
  }
}

ipcMain.handle('choose-file', async () => {
  const { canceled, filePaths } = await dialog.showOpenDialog({ properties: ['openFile'] });
  return canceled ? '' : filePaths[0];
});

ipcMain.handle('hash-file', async (event, jobId, filePath, algorithmId) => {
  const controller = new AbortController();
  jobs.set(jobId, controller);

  try {
    const result = await hashFile(filePath, algorithmId, {
      signal: controller.signal,
      onProgress: (percent) => event.sender.send('hash-progress', jobId, percent),
    });
    return { ok: true, ...result };
  } catch (error) {
    return { ok: false, message: describeError(error) };
  } finally {
    jobs.delete(jobId);
  }
});

ipcMain.on('cancel-hash', (_event, jobId) => {
  jobs.get(jobId)?.abort();
});

ipcMain.on('copy-text', (_event, text) => {
  clipboard.writeText(text);
});

app.whenReady().then(() => {
  Menu.setApplicationMenu(null);

  createWindow();

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) createWindow();
  });
});

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') app.quit();
});
