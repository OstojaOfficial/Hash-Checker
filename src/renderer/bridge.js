'use strict';

const api = window.hashChecker;

const progressHandlers = new Map();
let nextJobId = 1;

api.onProgress((jobId, percent) => progressHandlers.get(jobId)?.(percent));

function startHash(filePath, algorithmId, onProgress) {
  const jobId = nextJobId++;
  progressHandlers.set(jobId, onProgress);

  const done = api
    .hashFile(jobId, filePath, algorithmId)
    .finally(() => progressHandlers.delete(jobId));

  return { done, cancel: () => api.cancelHash(jobId) };
}
