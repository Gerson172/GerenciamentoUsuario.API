# GerenciamentoUsuario.API
 Projeto com o intuito concluir o desafio de criação de uma api restfull proposto pela Viceri
 
## Interface da aplicação
![Interface do projeto (Swagger)](https://user-images.githubusercontent.com/52055510/170613010-46e23260-19e7-43b6-b29f-6947e61abe13.png)

<p>O aplicativo tem com o intuito de realizar um CRUD de uma tabela de Usuarios (criar, buscar, atualizar e cancelar).<p>

## Após realizar o clone da api...
 
 Após clonar a API, é de suma importância __aplicar a database dentro do seu desktop__ com o Microsoft Sql server Management Studio para a realização dos testes.
 <br>
 Na raíz do projeto, execute esse comando no cmd: 
<!--sec data-title="Current directory: Windows" data-id="windows_cd" data-collapse=true ces-->
    C:\GerenciamentoUsuario.API> dotnet ef database update -s GerenciamentoUsuario.API
<!--endsec-->
 
 ![image](https://user-images.githubusercontent.com/52055510/170621785-51bf1ddb-5ecd-4fa8-99c2-a7a01746d043.png)

 Executando esse comando, será gerada uma database no seu localhost, podendo realizar os testes.
 
## O projeto está dividido em três camadas:
 
 ### GerenciamentoUsuario.API 
 <p>Possui as controllers e arquivos de configuração do projeto e conexão de strings</p>
 
 ![image](https://user-images.githubusercontent.com/52055510/170614787-0544a453-bb5e-4b55-bea2-6e01cdf26a0d.png)
 
 ### GerenciamentoUsuario.Application
 <p>Está sendo referenciado as duas outras camadas nele, não foi implementado classes ou quaiser códigos a ele.</p>
 
 ![image](https://user-images.githubusercontent.com/52055510/170615239-cde071cd-65ef-4bac-811e-4ff86f4528d3.png)
 
 ### GerenciamentoUsuario.Domain
 <p>Nessa camada concentra a model do projeto, onde foi implementada a DTO por questão de segurança da aplicação, para não exibir a User diretamente.</p>
 
 ![image](https://user-images.githubusercontent.com/52055510/170615442-56c29aba-1e93-48db-88a2-014c4afeb770.png)

### GerenciamentoUsuario.Persistence

<p>Nessa camada, é feita a persistência do projeto, com interfaces e repositórios. foram criadas interfaces para não utilizar os métodos "iniciais" diretamente.
 Foi usado o Dapper para implementar Scripts SQL para a realização do CRUD, o mesmo pode ser encontrado na UserRepository.cs. 
</p>

<p>
 Encontra-se as migrations dentro dessa camada, onde foi gerado a tabela do banco de dados pegando os objetos apontado no contexto disponível na classe DataContex.cs.
</p>

![image](https://user-images.githubusercontent.com/52055510/170615561-93703617-121f-43ce-a6cc-65610a8c34aa.png)

 ## Base de dados
 <p> Usei o SQL Server como base na aplicação, sendo que a criação de tabelas foram feitas por migrations pelo Entity Framework. Scripts T-SQL de CRUD 
 estão disponíveis dentro da camada GerenciamentoUsuario.Persistence, na classe User.Repository.cs </p>
 
 ## Senha em Hash
 Criptografia em Hash após o usuário realizar o cadastro foi consultada usando esse [artigo](https://docs.microsoft.com/pt-br/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-6.0) retirado diretamente da documentação da microsoft
 
 

 

