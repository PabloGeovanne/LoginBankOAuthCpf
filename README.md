# LoginBankOAuthCpf
Systemic testing for user registration and generation of authentication token for bank login using Microsoft System Security Claims and ASP.NET CORE 3.1 MVC validation methods

# Documentation pt-br
--- # ESCOPO # ---

Desenvolvimento de aplicação para realizar cadastro e login de usuário bancário, salvando informações em cookies para utilização e validação do login, observando algumas das boas práticas na segurança de dados.
Observado que no exemplo demostrado pelo cliente, o mesmo solicita que as informações de cadastro seja salva em cookies utilizando uma matriz de dados (array em JSON) não criptografada e também não realizando a geração de token para validar a sessão, embora seja nomeado uma variável “token” que na realidade se trata apenas de uma matriz de dados cadastrais e recuperadas quando se fizer necessário, e possivelmente visível para terceiros realizarem extração com técnicas de phishing, malware, spyware ou outros.
Pontos importante na segurança dos dados cadastrados, deverá ser aplicada como um bônus a atividade solicitada pela SOUE.

# REQUISITOS
1)	Página HTML simples conforme ilustração na imagem anexada (anexo 01).
2)	Na página inicial deverá conter os seguintes menus de navegações:
  a)	Abra sua conta
  b)	Investimento
  c)	Planos
3)	Acoplado ao menu de navegação no canto superior direito, deverá conter um campo do tipo “text” para a inserção de CPF valido, possibilitando o acesso a conta bancária.
4)	No requisito 3º, deverá conter botão para confirmar e submeter o dado CPF, sendo sua descrição “Acessar”.
5)	No requisito 3º, deverá possuir label informando ao usuário que se trata de um campo para acesso a conta bancária (Acesse sua conta).
6)	No requisito 3º, o campo para a digitação do CPF valido, deverá conter placeholder com informação para o usuário digitar o CPF (Digite seu CPF).
7)	No rodapé deverá conter uma página Footer com os links de fácil acesso seguintes: 
  a)	Traning Banking
    i)	Quem somos
    ii)	Nossos serviços
    iii)	Carreiras
    iv)	Desenvolvedores
  b)	Para você
    i)	Abra sua conta
    ii)	Cartões de crédito
    iii)	Créditos e financiamentos
    iv)	Investimentos pessoa física
  c)	Segmentos
    i)	Comercial banking
    ii)	Seguros
    iii)	Tesouro direto
8)	No corpo da página de cadastro, deverá possuir o formulário para a inserção no banco de dados.
9)	No requisito 8º, os campos de formulário para o preenchimento do usuário, deverá ser os seguintes:
  a)	Nome
  b)	CPF
  c)	E-mail
  d)	Telefone
  e)	Endereço
10)	Para realizar a submissão dos dados preenchidos no formulário descrito no requisito 9º, deverá conter um botão descrito com o seguinte texto “Cadastrar”.

# ARQUITETURA
Para o desenvolvimento da aplicação será utilizada a linguagem de programação ASP NET Core utilizando o padrão MVC (Model-View-Controller), tendo o backend em C# e o front em HTML com ASP podendo possuir funcionalidades em JavasCript no lado Client. 
Toda a codificação será realizada através da plataforma de desenvolvimento (IDE) Visual Studio 2019.
Os dados gerados pelos usuários serão armazenados em banco de dados MySQL.
Para as requisições dos dados transitados entre as camadas do software, será utilizando o padrão de troca de dados JSON.


