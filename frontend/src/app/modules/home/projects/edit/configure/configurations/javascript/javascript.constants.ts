export const index = (apiKey: string) => `import * as Watchdog from '@watchdog-bsa/watchdog-js';

Watchdog.init('${apiKey}');
Watchdog.enableCustomErrorHandling();`;
