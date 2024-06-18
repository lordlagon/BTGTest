# BTGTest

Seja bem vindo ao teste técnico do BTG Pactual

Criar um projeto, utilizando .NET Maui na versão 8, e implementar um cadastro de
clientes, aonde teremos uma tela que permitirá ao usuário incluir, modificar, excluir e
listar os clientes que temos em nosso cadastro, não será necessário que os dados
sejam persistidos, ou seja, será somente em memória durante a execução.

Requisitos:
1. Utilizar MVVM (Model View ViewModel) como principal padrão para
implementação;
2. A classe cliente deverá possuir:
a. Name
b. Lastname
c. Age
d. Address
3. A tela inicial deverá conter uma lista de clientes e permitir as operações de
Inclusão, Exclusão e Alteração dos clientes.
a. As telas referentes a estas ações devem abrir em uma nova janela e fechar ao
cancelar a operação, ou salvar a inclusão/alteração.
b. Para exclusão, pode ser utilizado uma mensagem de confirmação, do próprio
.NET Maui, ou criar a sua própria, utilizando uma nova janela
4. Utilizar injeção de dependência;
5. Publicar em um repositório privado no Github.com;

Opcionais
1. Persistir os dados da forma que preferir, permitindo que, ao executar novamente o
aplicativo, os dados sejam carregados e possam ser manipulados;
2. Testes unitários;
3. Verificação do tipo de dado digitado em cada campo, ex: Age não pode receber
uma letra;
4. Abrir a janela principal maximizada e as janelas referentes as operações de
cadastro, abrirem ao centro da tela;
