import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-password-settings',
  templateUrl: './user-password-settings.component.html',
  styleUrls: ['./user-password-settings.component.sass']
})
export class UserPasswordSettingsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  changePasswordVisibility(button: HTMLElement) {

    let input: Element = button.previousElementSibling;
    let icon: Element = button.firstElementChild;
    let iconClass: string = 'pi pi pi-eye';
    let inputType: string = 'password';

    if (input.getAttribute('type') === "password") {
      iconClass = 'pi pi-eye-slash';
      inputType = 'text';
    }
      icon.setAttribute('class', iconClass)
      input.setAttribute('type', inputType)
  }

}
