export interface Organization {
    id: number,
    name: string,
    organizationSlug: string,
    openMembership: boolean,
    trelloIntegration: boolean,
    trelloBoard: string,
    trelloToken: string,
    defaultRoleId: number,
    avatarUrl: string,
    createdBy: number,
    createdAt: Date
}
