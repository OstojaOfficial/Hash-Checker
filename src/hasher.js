'use strict';

const crypto = require('node:crypto');
const fs = require('node:fs');

// Velicina bloka odredjuje prikaza napretka i brzinu reakcije na otkazivanje.
const CHUNK_SIZE = 1024 * 1024;

// Heshuje se blok po blok, pa potrosnja memorije ne zavisi od velicine fajla.
async function hashFile(filePath, algorithmId, { onProgress, signal }) {
  const { size } = await fs.promises.stat(filePath);

  const hash = crypto.createHash(algorithmId);
  const stream = fs.createReadStream(filePath, { highWaterMark: CHUNK_SIZE, signal });

  let bytesRead = 0;
  let lastPercent = -1;
  const startedAt = performance.now();

  for await (const chunk of stream) {
    hash.update(chunk);
    bytesRead += chunk.length;

    const percent = size > 0 ? Math.floor((bytesRead * 100) / size) : 100;
    if (percent !== lastPercent) {
      lastPercent = percent;
      onProgress(percent);
    }
  }

  onProgress(100);

  return {
    hex: hash.digest('hex'),
    bytesRead,
    milliseconds: Math.round(performance.now() - startedAt),
  };
}

module.exports = { hashFile, CHUNK_SIZE };
