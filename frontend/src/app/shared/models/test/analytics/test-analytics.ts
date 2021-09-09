import { ResponseTimes } from '@shared/models/test/analytics/response-times';
import { ResponseCounts } from '@shared/models/test/analytics/response-counts';
import { Bandwidth } from '@shared/models/test/analytics/bandwidth';

export interface TestAnalytics {
    testId: number,
    requestId: number,
    responseTimes: ResponseTimes,
    responseCounts: ResponseCounts,
    bandwidth: Bandwidth
}
