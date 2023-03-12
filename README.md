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

## To start the project locally

### Requirements

* .Net 7.0;
* Microsoft SQL Server;
* [EF Core tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet);
* [Stripe CLI](https://stripe.com/docs/stripe-cli) and Stripe account for test purchases;
* SendGrid account for sending emails;

### Installation

1) Clone repository:
```shell
git clone https://github.com/papaphua/BlazorShop.git
```
2) Apply migration within the server folder:
```shell
dotnet ef database update
```
3) Set secrets within the server folder:
```shell
dotnet user-secrets set "Secrets:JwtSecretKey" "YOUR_JWT_SECRET_KEY"
dotnet user-secrets set "Secrets:StripePrivateKey" "YOUR_STRIPE_PRIVATE_KEY"
dotnet user-secrets set "Secrets:StripeWebHookSecret" "YOUR_STRIPE_WEBHOOK_SECRET"
dotnet user-secrets set "Secrets:SendGridApiKey" "YOUR_SENDGRID_API_KEY"
```
4) 
```shell
stripe listen --forward-to localhost:7005/api/payments/webhook
```
5) Run BlazorShop.Server: https

