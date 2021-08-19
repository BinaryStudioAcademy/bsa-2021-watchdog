import { Breadcrumb } from "@core/collecting-errors/models/breadcrumb";
import { PrimeIcons } from "primeng/api";

export const getIconAndColor = (breadcrumb: Breadcrumb) => {
    switch (breadcrumb.type) {
        case 'navigation':
            
            return {icon: PrimeIcons.MAP_MARKER, color: 'rgb(51, 191, 158)'}

        case 'debug':
        
            return {icon: PrimeIcons.COG, color: 'rgb(108, 95, 199)'}

        case 'error':
        
            return {icon: PrimeIcons.EXCLAMATION_TRIANGLE, color: 'rgb(245, 84, 89)'}

        case 'http-request':
        
            return {icon: PrimeIcons.GLOBE, color: 'rgb(181, 191, 51)'}   

        case 'user-action':
    
            return {icon: PrimeIcons.USER, color: 'rgb(51, 151, 191)'}
    }
};

//'navigation' | 'debug' | 'error' | 'http-request' | 'user-action'
