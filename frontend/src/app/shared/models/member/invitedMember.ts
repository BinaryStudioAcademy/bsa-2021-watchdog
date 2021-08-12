import { HttpResponse } from "@angular/common/http";
import { Member } from "./member";

export interface InvitedMember {
    member: Member;
    statusCode: number;
}