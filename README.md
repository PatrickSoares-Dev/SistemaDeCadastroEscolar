# Sistema de Cadastro Escolar

## Resumo
O sistema de cadastro escolar é uma aplicação desenvolvida em C# utilizando o framework .NET. Ele permite a inserção, exclusão e edição de escolas, turmas, alunos e matérias em um banco de dados. Além disso, o sistema oferece métodos de validação e outras funcionalidades relacionadas ao cadastro escolar.

## Funcionalidades

### AlunoController
- **Index**: Retorna a página inicial do sistema.
- **Adicionar**: Adiciona um novo aluno ao sistema, recebendo como parâmetros o ID da escola, o ID da turma, o nome completo, CPF e data de nascimento do aluno.
- **BuscarTodos**: Retorna todos os alunos cadastrados no sistema.
- **InfoAluno**: Retorna as informações de um aluno específico com base no CPF fornecido.
- **EditarAluno**: Edita as informações de um aluno com base no CPF fornecido, como o status de cadastro, turma e escola.
- **ApagarAluno**: Remove um aluno do sistema com base no CPF fornecido.
- **GetNameTurmaEEscola**: Retorna o nome da turma e da escola com base nos IDs fornecidos.

### EscolaController
- **Index**: Retorna a página inicial do sistema.
- **Adicionar**: Adiciona uma nova escola ao sistema, recebendo como parâmetro o nome da escola.
- **GetEscolasTurmasAlunos**: Retorna todas as escolas, turmas e alunos cadastrados no sistema.
- **InfoEscola**: Retorna as informações de uma escola específica com base no nome fornecido.

### AlunosRepositorio
- **BuscarTodos**: Retorna todos os alunos cadastrados no sistema.
- **Adicionar**: Adiciona um novo aluno ao sistema, recebendo como parâmetros o ID da escola, o ID da turma, o nome completo, CPF e data de nascimento do aluno.
- **InfoAluno**: Retorna as informações de um aluno específico com base no CPF fornecido.
- **EditarAluno**: Edita as informações de um aluno com base no CPF fornecido, como o status de cadastro, turma e escola.
- **ApagarAluno**: Remove um aluno do sistema com base no CPF fornecido.
- **GetNameTurmaEEscola**: Retorna o nome da turma e da escola com base nos IDs fornecidos.

### TurmaRepositorio
- **BuscarTodos**: Retorna todas as turmas cadastradas no sistema.
- **Adicionar**: Adiciona uma nova turma ao sistema, recebendo como parâmetros o nome da escola e o nome da turma.
- **ObterTurmas**: Retorna todas as turmas cadastradas no sistema.
- **ObterTurma**: Retorna as informações de uma turma específica com base no ID fornecido.
- **ContarAluno**: Retorna a quantidade de alunos matriculados em uma turma específica com base no ID fornecido.
- **ObterAlunosDaTurma**: Retorna todos os alunos matriculados em uma turma específica com base no ID fornecido.

## Como Executar
1. Clone o repositório em sua máquina local.
2. Abra a solução (.sln) no Visual Studio.
3. Certifique-se de ter o banco de.
4. Certifique-se de ter o banco de dados configurado corretamente. O sistema utiliza um banco de dados SQL Server para armazenar as informações. Você pode criar o banco de dados manualmente ou utilizar um arquivo de script para criar as tabelas necessárias. Certifique-se de fornecer as informações de conexão corretas no arquivo de configuração do sistema.
5. Compile execute o projeto no Visual Studio. Isso iniciará o servidor local e abrirá a página inicial do sistema no navegador.
6. Na página inicial, você poderá utilizar as funcionalidades do sistema de cadastro escolar. Dependendo da sua necessidade, você pode escolher entre as funcionalidades disponíveis nos controladores AlunoController e EscolaController.
7. No AlunoController, você poderá adicionar novos alunos, buscar todos os alunos cadastrados, obter informações de um aluno específico, editar informações de um aluno existente e apagar um aluno do sistema.
8. No EscolaController, você poderá adicionar novas escolas, obter informações de uma escola específica e obter uma lista de todas as escolas, turmas e alunos cadastrados no sistema.
9. Para interagir com as turmas, você pode utilizar as funcionalidades disponíveis no TurmaRepositorio. É possível adicionar novas turmas, obter informações de uma turma específica, contar o número de alunos matriculados em uma turma e obter a lista de alunos matriculados em uma turma.
10. Certifique-se de seguir as diretrizes e restrições fornecidas pelo sistema ao inserir informações. O sistema possui validações para garantir a consistência dos dados.
11. Explore as funcionalidades do sistema e utilize as opções de menu ou formulários fornecidos para interagir com o cadastro escolar.
