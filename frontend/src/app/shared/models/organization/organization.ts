export interface Organization {
    id: number,
    name: string,
    organizationSlug: string,
    openMembership: boolean,
    defaultRoleId: number,
    avatarUrl: string,
    createdBy: number,
    createdAt: Date
}
