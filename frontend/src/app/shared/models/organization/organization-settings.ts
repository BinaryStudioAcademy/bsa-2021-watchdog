export interface OrganizationSettings {
    name: string,
    organizationSlug: string,
    openMembership: boolean,
    defaultRoleId: number,
    trelloIntegration: boolean,
    trelloBoard: string,
    trelloToken: string,
}
