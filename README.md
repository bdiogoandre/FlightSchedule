# Flight Schedule

## Cadastro em .NET Core Web API + Angular + Material + MongoDB
Este projeto é um exemplo de um cadastro básico de um agendador de voos.
* Arquitetura baseada em DDD (Domain Driven Design).
* Simples teste unitário utilizando TDD com xUnit e NSubstitute.
* Injeção de dependências.
* Autenticação com OAuth JWT do .NET Core.

O objetivo é compartilhar um pouco da experiência acerca do desenvolvimento WEB utilizando novas tecnologias.

### Tecnologias Utilizadas 

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core)
* [C# for Visual Studio Code 1.21.0](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Angular 8.2](https://angular.io/docs)
* [Angular Flex-Layout](https://github.com/angular/flex-layout)
* [Angular Material](https://material.angular.io/)
* [Atlas](https://www.mongodb.com/cloud/atlas)
* [MongoDB](https://www.mongodb.com/)
* [Typescript 3.5.3](https://www.typescriptlang.org/docs/home.html)
* [HTML](https://www.w3schools.com/html)
* [CSS](https://www.w3schools.com/css)

O projeto de **FRONTEND** está separado do projeto de **BACKEND** e as duas aplicações devem ser executadas separadamente através dos passos abaixo.

Faça o clone desse repositório em sua máquina local e realize os procesimentos.

### Como Executar

#### ATRAVÉS DA LINHA DE COMANDO
#### Pré-requisitos

**Instale as ferramentas abaixo**
* [.NET Core SDK](https://aka.ms/dotnet-download)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Passos

1. Abra o diretório **FlightSchedule\Frontend** na linha de commando e execute **npm install --save** em seguida **ng serve --open**
* Irá instalar todas as dependências e executar a aplicação Angular em seu navegador.

2. Abra o diretório **FlightSchedule\Backend\FlightSchedule** na linha de commando e execute **dotnet run**
* Irá executar o applicativo de servidor em sua máquina local.

3. Abra <http://localhost:4200> em seu navegador.


#### ATRAVÉS DO VISUAL STUDIO CODE
#### Pré-requisitos

**Instale as ferramentas abaixo**
* [.NET Core SDK](https://aka.ms/dotnet-download)
* [Visual Studio Code](https://code.visualstudio.com)
* [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Passos

1. Abra o diretório **FlightSchedule\Frontend** na linha de commando e execute **npm install --save**
2. Abra o diretório **FlightSchedule\Backend\FlightSchedule** no Visual Studio Code.
3. Pressione **F5** ou **CTRL + F5** para iniciar.
4. Abra http://localhost:4200 em seu navegador

#### ATRAVÉS DO VISUAL STUDIO
#### Pré-requisitos

**Instale as ferramentas abaixo**
* [.NET Core SDK](https://aka.ms/dotnet-download)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Passos

1. Abra o diretório **FlightSchedule\Frontend** na linha de commando e execute **npm install --save**
2. Abra a solution **FlightSchedule\Backend\FlightSchedule\Airport.FlightSchedule.sln** no Visual Studio.
3. Pressione **F5** ou **CTRL + F5** para iniciar.
4. Abra http://localhost:4200 em seu navegador

#### Login e Senha para acessar.
##### Login: admin
##### Senha: 123456

## E divirta-se!!!
