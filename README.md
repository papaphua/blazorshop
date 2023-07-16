![BlazorShop-logo](https://imgur.com/nQj4gmy.png)

# BlazorShop

## About the project

> BlazorShop is a shopping websites with the following features:
> 1) **JSON Web Token** authentication with refresh token implementation;
> 2) **Two-factor** authentication;
> 3) **Permission-based** authorization;

## Implemented services

> 1) [**Stripe**](https://stripe.com) payments;
> 2) [**SendGrid**](https://sendgrid.com) emails;

## Client design

> [**Blazorise**](https://blazorise.com/) with [**Material**](https://djibe.github.io/material/) css framework;

## Links

> * [**BlazorShop**](https://blazorshopserver.azurewebsites.net/) - web site;
> * [**Swagger**](https://blazorshopserver.azurewebsites.net/swagger/index.html) - API;

## To start the project locally

### Requirements

* .Net 7.0;
* Microsoft SQL Server;
* [EF Core tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet);
* [Stripe CLI](https://stripe.com/docs/stripe-cli) and Stripe account for test purchases;
* SendGrid account for sending emails;

### Installation

1) Clone repository
```shell
git clone https://github.com/papaphua/BlazorShop.git
```
2) Apply migration within the server project root folder
```shell
dotnet ef database update
```
3) Execute stripe listen command to receive events
```shell
stripe listen --forward-to localhost:7005/api/payments/webhook
```
4) Create .env file in server project root folder with following content
```text
JWT_SECRET_KEY=YourValue        // any value to generate and verify tokens
STRIPE_PRIVATE_KEY=YourValue    // from dashboard.stripe.com/test/apikeys
STRIPE_WEBHOOK_SECRET=YourValue // stripe webhook secret received after executing stripe listen command
SENDGRID_API_KEY=YourValue // from app.sendgrid.com/settings/api_keys
```
5) Run BlazorShop.Server: https

## Screenshots

1) Products pages
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/products.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/products_search.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/product.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/comments.png?raw=true)
2) Cart pages
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/cart.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/stripe_checkout.png?raw=true)
3) Auth pages
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/login.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/register.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/confirmation_email.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/email_confirmed.png?raw=true)
4) Profile pages
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/profile.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/email_change.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/password_change.png?raw=true)
5) Management pages
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/products_management.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/products_management_search.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/users_management.png?raw=true)
![alt text](https://github.com/papaphua/BlazorShop/blob/main/screenshots/add_product.png?raw=true)