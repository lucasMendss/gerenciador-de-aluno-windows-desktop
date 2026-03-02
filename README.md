# 📦 Gerenciador de Alunos

Aplicativo desktop desenvolvido em **Windows Forms (.NET 8)**  com foco em orientação a objetos, banco de dados relacional, organização de código, interface e experiência do usuário. 

Permite consulta de um aluno por vez através de Prontuário, CPF, RG ou E-mail fictícios, além de cadastro, atualização e exclusão de registros. 

---

## 🚀 Tecnologias Utilizadas

- **C# / .NET 8**
- **Windows Forms**
- **PostgreSQL (Constraints, permissões de Roles, Edge Function)**
- **Github Actions**

---

## 🖥️ Requisitos do Sistema

- **Windows 10** ou **Windows 11**
- Arquitetura de processador **x64**
- Microsoft Windows Desktop Runtime

---

## 📥 Instalação

1. Baixe o arquivo instalador (`setup-instalacao-gerenciador-de-aluno.exe`)
2. Execute o instalador
3. Siga os passos de instalação
4. Abra o aplicativo normalmente
5. Caso ainda não tenha instalado o Windows Desktop Runtime*, o sistema irá solicitar a instalação quando você tentar abrir o app 
* *O Desktop Runtime é um pacote da Microsoft que fornece os arquivos e bibliotecas necessários para executar aplicativos de desktop no Windows.
---

## 🗄️ Infraestrutura e Banco de Dados

### ⚠️ Importante (leia antes)

Este projeto utiliza um **banco de dados público e descartável**, criado exclusivamente para fins de **demonstração**. Para viabilizar a experiência *“baixar → instalar → usar”*, a aplicação contém credenciais de acesso a essa base de dados.

Isso foi uma **decisão consciente**, com o objetivo de permitir que qualquer pessoa possa testar o aplicativo imediatamente após a instalação.

### Como funciona

- O banco de dados está hospedado no **Supabase (PostgreSQL)**
- Utiliza uma **role limitada**, com permissões apenas para:
  - Criar
  - Ler
  - Atualizar
  - Excluir  
  dados nas tabelas necessárias
- **Não possui permissões administrativas**
- **Não contém dados reais ou sensíveis**
- Pode ser **resetado ou removido a qualquer momento**

---
