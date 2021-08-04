// edit this when you need
export interface Platform {
    id: number,
    name: string,
    avatarUrl: string
    isBrowser?: boolean,
    isServer?: boolean,
    isMobile?: boolean,
    isDesktop?: boolean
}
