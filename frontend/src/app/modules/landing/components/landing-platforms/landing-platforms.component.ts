/* eslint-disable max-len */
import { Component } from '@angular/core';

@Component({
    selector: 'app-landing-platforms',
    templateUrl: './landing-platforms.component.html',
    styleUrls: ['./landing-platforms.component.sass']
})
export class LandingPlatformsComponent {
    urls = [
        'https://www.sentry.dev/_assets2/static/f3663bf3904adcea0d835bc0ed00a76e/5e011/dotnet.webp',
        'https://topreviewhostingasp.net/wp-content/uploads/2017/08/asp-net-logo.png',
        'https://www.freeiconspng.com/uploads/c-logo-icon-18.png',
        'https://www.sentry.dev/_assets2/static/d68867cb09825ed57929417741df8676/5e011/javascript.webp',
        'https://angular.io/assets/images/logos/angularjs/AngularJS-Shield.svg',
        'https://www.sentry.dev/_assets2/static/24ef7069eeae638c5b3759fb927cd8ec/5e011/react.webp',
        'https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Stack_Overflow_icon.svg/768px-Stack_Overflow_icon.svg.png',
        'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAb1BMVEUAeb////8Ab7vc5/IAbbr09/vP3u4Adr4AdL0AcbwAbrsAc70Ae8Dj7vb5/P6oyOMqhsW0z+dwpdITf8JLlMvJ3u6Tu916rdary+XV5fLt9fobgcJCkMnC2ew0isZVmc2FtNqbwOBkodGJttpdnc8BW58gAAAFFElEQVR4nO2d63aiMBRGk1SbcJGLiIh367z/Mw7o2GprQTiBQObbP7u6PNkkOUCAE8afMYvP832UsLHgR9v5MZ49dWE//7SbJ8JT0nSrmyGl8twky+sNgyUTI5O7Q4korDE8Kc90K2lIx19VGKYbx3QLNSD2+W+G2YjH5z3SXT41DLY2dOAVcQh+Gq4TOzrwikqm3w3Xvk2CxUj1p4+GgVU9WCKT4MFwoUy3SDtqcW94tCfJfOEsvwzTienWdIKbfxpubJuEV2R0M1zaOEZLnPBqGNiXZW74V8PlyC+2Kyg7sTC0cxJekJvScGfrLCxx08Lww+I+ZCrjLLBZkLGEs1yYbkSniBkL7T1XlDgxy+wepWrJFnYbyjnbmG5Dt8it6RZ0TmS6AZ3jv/qP0nPE6zhe8wytGkbQmj+k8Odhmr+9TLrKErdJE5SbZKv09QB5Gs59fcu7YpHy5uSH168lxJ8nj1RqSRd6rlakiltEv7SAvXaQpd/mCJbEOh6RyWjdMny5jP7KradaBPU/9Qtr+gKMjNqHL9jWN+C26teOgKwop/VRqqh9jlzepFJYE1coxI4Wn7/XLVRO2uSYe2JSupEHYnjO59WjqLhFpfLCTPgd950c/636ELvPXy9owo7SicQ5ciGqOsRyqyECQVDDEOL8XJUK1ElDBMJKk9f2XH9P5Vqe0/Zcf0/YPp069GlYXL1VTRMN07DmGFYj3jTEX1cZToin2wuExTQthtOqM6IWw5p0DUMyMKQDQxhSgSEdGMKQCgzpwBCGVGBIB4YwpAJDOjCEIRUY0oEhDKnAkA4MYUgFhnRgCEMqMKQDQxhSgSEdGMKQCgzpwBCGVGBIB4YwpAJDOjCEIRUY0oEhDKnAkA4MYUgFhnRgCEMqMKQDQxhS+c8NRfsCRl8M+nt8K2oqVBo61Ao/JYS6GN0besv6H6ilpsiPWUO51xDh5cKBJgyZSw9BqTHUg6H8IAfYE+pE9WDIJtQaPCtKte4+DJlPKnnHZ6Ry5L0Y0ophTWmbq/RiyNS+/aXbjLg9Tj+GTLG25/2QWqe1J8Mi0LZFvgniiLwlQG+GTAr2cdq9v058OkgNNWj7MywlldMEPXWEezU0AgxhCEPzwBCGMDQPDGEIQ/PAEIYwNA8MYQhD88AQhjA0DwxhCEPzwBCGMDQPDGEIQ/PAEIYwNI/9hlr20Jy5pjUqcHTsQ5qSXyDsEHXUYEj43qN7ZKTBcKHlJcKumNBTzXrI07DoxDnZsHLD4wEgqDufr4ecZ0qou9eTPmjpB/WHJJgNfIyWOBTFbOhj9IIXtf3Oc70dQQ+WyMm5zde606WGrwX6wnMWYd7Ecp2HB0+ZbnYjpCfEpAFCz+cQAAAAAAAAWAOh9MkoSFhkugkdE7HhLxWRkHtGKEE0BuScncd1K94UdWbxKJbDWuPEbNCP9+i4M0aplDUCEs54ZvNEVMfCMCUUAxs8Ii8MeWK6Gd1RPuItDE/2ZlMnvBhanGt8fjUMbe1EsfpnyCM7r9yuZScvhvmQX1tqz7Xq5MWQn20cp+JaG/VqyA/2nfbVgd8bBhvbFOUmeDCkVlgcHCq5FWO8GVrWi2rzWW3y05DzhT3pRhy+iqLeGfKla8dIlZP7CtP3hjzf2NCNTvTwqtqDYXEBJ0fyCsxvSMcPH5W+GfLglLjjTTlKRN/8fhoWpFkiHCXHNSel9Bw3yd5/6jwxLJjFx4/tZjx3VX60zZa752+n/QViOnRlypI6tgAAAABJRU5ErkJggg=='
    ];
}
