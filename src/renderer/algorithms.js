'use strict';

const algorithms = [
  { name: 'SHA-256',     id: 'sha256',     hexLength: 64  },
  { name: 'SHA-512',     id: 'sha512',     hexLength: 128 },
  { name: 'SHA-1',       id: 'sha1',       hexLength: 40  },
  { name: 'MD5',         id: 'md5',        hexLength: 32  },
  { name: 'SHA3-256',    id: 'sha3-256',   hexLength: 64  },
];

function normalizeHash(text) {
  let candidate = text.trim();

  const space = candidate.search(/\s/);
  if (space > 0) {
    candidate = candidate.slice(0, space);
  }

  candidate = candidate.toLowerCase();

  return /^[0-9a-f]+$/.test(candidate) ? candidate : '';
}

function detectAlgorithm(normalizedHash) {
  return algorithms.findIndex((entry) => entry.hexLength === normalizedHash.length);
}
