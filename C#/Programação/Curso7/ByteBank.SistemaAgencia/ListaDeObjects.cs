using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObjects
    {
        private object[] _itens;
        public int _proximaPosicao;
        public int Size {
            get {
                return _proximaPosicao;
            }
        }

        //indexador var[1]
        public object this[int index] {
            get {
                return GetItemIndex(index);
            }
        }

        //indexador var[1, 2, 3]
        public object[] this[params int[] indexs] {
            get {
                object[] contas = new object[indexs.Length];
                for (int i = 0; i < indexs.Length; i++)
                {
                    contas[i] = GetItemIndex(indexs[i]);
                }

                return contas;
            }
        }
        public ListaDeObjects(int capacidadeInicial = 5)
        {
            _itens = new object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(object item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void Remover(object item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            if (indiceItem != -1)
            {
                for (int i = indiceItem; i < _proximaPosicao - 1; i++)
                {
                    _itens[i] = _itens[i + 1];
                }

                _proximaPosicao--;
                _itens[_proximaPosicao] = null;

                //Console.WriteLine("Removeu");
            }
        }

        public object GetItemIndex(int index)
        {
            if (index < 0 || index >= _proximaPosicao)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _itens[index];
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
                return;

            //Console.WriteLine("Aumentando Capacidade da lista");

            int novoTamanho = _itens.Length * 2;

            if (tamanhoNecessario > novoTamanho)
                novoTamanho = tamanhoNecessario;

            object[] novaLista = new object[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                //Console.WriteLine('.');
                novaLista[i] = _itens[i];
            }

            _itens = novaLista;
        }

        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }
    }
}
