using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GerenciadorDeAluno
{
    public static class Validacoes
    {
        public static bool ValidarProntuario(string prontuario)
        {
            //separar dígitos posteriores a 'RA'
            string numerosProntuario = prontuario.Substring(2);
            //verificar se estrutura do prontuário corresponde a 'RA1234567'              
            if (!Regex.IsMatch(prontuario, "^RA[0-9]{7}$"))
            { return false; }
            return true;
        }
        public static bool ValidarNome(string nome)
        {
            //retirar caracteres especiais
            nome = nome.Replace(".", "").Replace("-", "").Replace("/", "");

            //verificar se há mais de 3 letras
            if (nome.Length < 4 || !Regex.IsMatch(nome, @"^[\p{L} ]+$"))
            { return false; }
            return true;
        }
        public static bool ValidarCPF(string cpf)
        {
            //retiro caracteres especiais e espaços
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");

            //verificar se há 11 números
            if (cpf.Length != 11 || !Regex.IsMatch(cpf, @"^[0-9]+$")) 
                { return false; }
            return true;
        }

        public static bool ValidarRG(string rg)
        {
            //retirar caracteres especiais e espaços
            rg = rg.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");

            //verificar se há 9 números
            if (rg.Length != 9 || !Regex.IsMatch(rg, @"^[0-9]+$"))
                { return false; }
            return true;
        }
        public static bool ValidarEmail(string email)
        {
            //verifica se nada foi digitado
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            //verifica estrutura padrão de email (com @ e .com)
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
