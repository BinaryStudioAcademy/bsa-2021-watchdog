export const setUser = `//In authentication services on login and when pages loads
//with authenticated user
const user = getCurrentUser();
Watchdog.setUserInfo({ identifier: user.email, fullName: user.fullName })

//When logout
Watchdog.setUserInfo({ isAnonymous: false });`;
