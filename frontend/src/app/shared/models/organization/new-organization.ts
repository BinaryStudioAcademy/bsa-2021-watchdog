export interface NewOrganization {
    name: string,
    organizationSlug: string,
    openMembership: boolean,
    defaultRoleId: number,
    avatarUrl?: string,
    createdBy: number
}
