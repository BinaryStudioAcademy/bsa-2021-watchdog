import { User } from "@shared/models/user/user";
import { Organization } from "@shared/models/organization/organization";
import { Member } from "@shared/models/member/member";

export interface Team {
    id: number,
    name: string,
    createdBy: number,
    user: User,
    organizationId: number,
    organization: Organization,
    members: Member[],
    createdAd: Date
}
