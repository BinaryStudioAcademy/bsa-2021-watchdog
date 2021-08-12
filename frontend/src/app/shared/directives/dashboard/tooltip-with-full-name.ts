import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[appTooltipFullName]'
})
export class TooltipWithFullNameDirective {
    constructor(private elementRef: ElementRef) { }

    @HostListener('mouseover') onMouseEnter() {
        const element: HTMLElement = this.elementRef.nativeElement;
        if (element.offsetWidth < element.scrollWidth) {
            element.title = element.textContent;
        }
    }
}
