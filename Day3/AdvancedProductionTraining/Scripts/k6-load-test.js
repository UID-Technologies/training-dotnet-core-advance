import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '30s', target: 20 },
    { duration: '1m', target: 50 },
    { duration: '30s', target: 0 },
  ],
  thresholds: {
    http_req_duration: ['p(95)<500'],
    http_req_failed: ['rate<0.05'],
  },
};

const baseUrl = __ENV.API_URL || 'http://localhost:5250';

export default function () {
  const payload = JSON.stringify({
    customerName: `LoadTest-${__VU}`,
    total: 100 + __ITER,
    customerTier: 'BRONZE',
  });

  const params = { headers: { 'Content-Type': 'application/json' } };

  const create = http.post(`${baseUrl}/api/orders`, payload, params);
  check(create, {
    'create status 201': (r) => r.status === 201,
  });

  const health = http.get(`${baseUrl}/health`);
  check(health, {
    'health status 200': (r) => r.status === 200,
  });

  sleep(1);
}
