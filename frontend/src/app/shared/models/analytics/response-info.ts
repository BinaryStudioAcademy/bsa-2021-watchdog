import { Project } from '@shared/models/projects/project';

export interface ResponseInfo {
    date: Date,
    time: number,
    url: string,
    status: string,
    statusText: string,
    size: number,
    projectKey: string
    project: Project
}
