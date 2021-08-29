export const index = (apiKey: string) => `import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as Watchdog from '@watchdog-bsa/watchdog-js';

Watchdog.init('${apiKey}');
Watchdog.enableCustomErrorHandling();

ReactDOM.render(<App />, document.getElementById("root"));

// Can also use with React Concurrent Mode
// ReactDOM.createRoot(document.getElementById('root')).render(<App />);`;
