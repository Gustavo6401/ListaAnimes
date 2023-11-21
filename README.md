# Seja Muito Bem-Vindo à Lista de Animes! 👨🏼‍💻

Esse projeto tem por objetivo resolver um problema totalmente meu. Particularmente eu sofro muito na hora de assistir um anime, pois muitas vezes eu dependo do histórico de exibição do meu navegador para saber em qual episódio estou. Além disso, se eu anoto isso num bloco de notas, ou algo do tipo, infelizmente eu posso acabar perdendo o arquivo de bloco de notas. Mas um aplicativo Desktop orientado à Web pode me ajudar muito com isso! Dado que eu costumo assistir meus animes pelo meu computador. 

## 1 - Como isso funciona? 🤔

Eu criei uma WebAPI com o objetivo de fazer a transição entre a camada de apresentação e o banco de dados, além disso, utilizei diversos conceitos utilizados no mercado de trabalho para a resolução desse problema:

- Domain Driven Design
- Test Driven-Development
- Control Inversion
- Dependency Injection
- API Rest
- AutoMapper.

Como vocês podem ver na pasta "Teste Unitario", literalmente cada unidade mínima de código é devidamente testada e bem cuidada, afim de manter a melhor qualidade e durabilidade para o meu software. Além disso, caso eu venha futuramente a hospedar esse site, certamente eu precisarei de uma boa arquitetura e de uma boa separação de responsabilidades. 

## 2 - Vamos falar sobre arquitetura? 💻

Como eu havia dito, dois princípios governaram a criação do meu código. Inicialmente eu criei uma solução chamada "Lista de Animes", que tinha objetivo de ser uma WebAPI e um Aplicativo Front-End com o Blazor WebAssembly.

### 2.1 - Primeiramente, vamos aos testes unitários 🤓

Os testes unitários tiveram o objetivo de cobrir 100% do código do Back-End, desde validar o modelo de dados até as requisições na classe Controller. Eu sei, testes unitários não tem por objetivo validar camadas de dados, mas eles foram necessários para evitar a implementação de Domínios Anêmicos e criar a funcionalidade nos domínios, tais como a funcionalidade de mostrar a porcentagem concluída do anime.

### 2.2 - Vamos falar sobre a arquitetura de fato da API?

A utilização de Biblioteca de classes foi pensada para facilitar a manutenção e reaproveitamento do código. O mesmo código presente, por exemplo na camada de Domínio, pode ser reaproveitado pela camada de apresentação ou até mesmo pela API. O código é dividido em quatro camadas principais:

- Domínio;
- Infraestrutura;
- API;
- Aplicação.

Por isso, falarei nesse arquivo sobre as subdivisões de cada camada:

#### 2.2.1 - Domínio

A camada de domínio foi dividida em uma única biblioteca de classes chamada "Dominio". O objetivo do Domínio era conter todas as entidades, regras de negócio, agregações, objetos de valor e métodos para as entidades. Além claro, das Interfaces. As Interfaces estão sendo utilizadas tanto nas classes Repository quanto nas classes Services e Controller, o objetivo delas é fazer o esquema de injeção de dependências e inversão de controle. 

##### 2.2.1.1 - Entities e DTOs

As classes Entities e DTOs são o coração do meu sistema. Nelas, estão as classes mais importantes, AnimeDTO e Anime. Essas classes são importantes por concentrarem o coração do meu projeto, as validações do sistema e alguns métodos que podem alterar os dados ali inseridos.

##### 2.2.1.2 - Interfaces

As Interfaces são uma camada extremamente importante da lista de Animes, por meio delas, vai ocorrer o esquema de injeção de dependência, além disso, elas vão determinar os métodos e configurar seus tipos de retorno, com o objetivo de determinar as regras de implementação de cada um dos métodos. As Interfaces são divididas entre duas subpastas: Repositories e Services. 

#### 2.2.2 - Infraestrutura

A camada de Infraestrutura conta com dois projetos: O projeto Infra.Data e Servicos. Logo mais, falaremos mais detalhadamente sobre cada um deles:

##### 2.2.2.1 - Infraestrutura.Data

Esse projeto tem por objetivo fazer a relação entre a aplicação e o banco de dados, todas as persistências e consultas ao banco de dados vão ocorrer por meio das operações definidas nesse projeto. O projeto Infraestrutura.Data conta com o ORM EntityFrameworkCore, que será responsável por fazer todas as operações de acesso a banco de dados, desde a geração, até a persistência e consulta aos dados. 

###### 2.2.2.1.1 - Infraestrutura.Data - Repositories

A camada de Repositórios será responsável pelas operações de persistência e consulta no banco de dados. 

###### 2.2.2.1.2 - Infraestrutura.Data - Context

A partir do DbContext, o EntityFramework será capaz de se comunicar e gerar as migrations que serão usadas para a geração do banco de dados. 

#### 2.2.2.2 - Servicos

A camada de serviços é uma camada importantíssima da aplicação. Ela será responsável por fazer a comunicação entre os Controllers e os Repositories, além de claro, ser capaz de utilizar o AutoMapper. É nela que as operações e transações com o AutoMapper serão realizadas. 

#### 2.2.3 - API

A API é a parte responsável pelo Roteamento e comunicação entre o Front-End e as camadas de dados. Além disso, a Program da API vai conter todas as informações necessárias para realizar a Injeção de Dependência e a Inversão de Controle. A API vai rodar por padrão na Visual Studio na Porta 7010 e ela vai se comunicar diretamente com a camada Services, dependendo dela. 

### - 2.3 - Front-End

O Front-End, como já foi dito acima, será desenvolvido em Blazor WebAssembly, afim de aprendermos mais sobre essa tecnologia e buscarmos o meu desenvolvimento na Plataforma .Net. 

Nessa branch, a API foi testada de ponta a ponta, em que os 28 teste unitários garantiram a Integridade do projeto e mostraram que ele está pronto para a utilização. O próximo passo é implantar o Front-End própriamente dito.