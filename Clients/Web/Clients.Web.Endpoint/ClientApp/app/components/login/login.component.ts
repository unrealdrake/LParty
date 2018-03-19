import { Component } from '@angular/core';
import { Http } from '@angular/http';
import GetUserProfileDto = Clients.Web.Endpoint.ClientApp.app.models.GetUserProfileDto;


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    constructor(private http: Http) {}

    email = "";
    password = "";
    getUserProfileDto: GetUserProfileDto;

    login(): void {
        this.http.get<GetUserProfileDto>(Urls.userProfileBase).subscribe((data) => {this.getUserProfileDto = data;});
    }
}
