const rejectMessage = 'Token request rejected';

export const authorizeIntegration = (apiKey: string,
    receiveMessage: (token: string) => any) => {
    const key = apiKey;
    const width = 500;
    const height = 600;
    const left = window.screenX + (window.innerWidth - width) / 2;
    const top = window.screenY + (window.innerHeight - height) / 2;
    const { origin } = window;
    const authUrl = `https://trello.com/1/authorize?return_url=${origin}
        &callback_method=postMessage&expiration=never&name=Watchdog&key=${key}&scope=read,write,account`;
    const w = window.open(authUrl, 'trello', `width=${width},height=${height},left=${left},top=${top}`);
    const receiveIndataMessage = (ev: MessageEvent<any>) => {
        if (ev.data !== rejectMessage) {
            receiveMessage(ev.data);
        } else receiveMessage(null);
        window.removeEventListener('message', receiveIndataMessage, false);
        w.close();
    };
    const timer = setInterval(() => {
        if (w.closed) {
            clearInterval(timer);
            window.postMessage(rejectMessage, origin);
        }
    }, 800);
    window.addEventListener('message', receiveIndataMessage, false);
};
