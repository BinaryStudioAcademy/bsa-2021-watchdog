export interface Issue {
    name: string,
    description: string,
    isNew: boolean,
    projectTag: string,
    createdAt: Date,
    events: number,
    users: number
} 