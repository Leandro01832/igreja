﻿using System;

namespace AplicativoXamarin.models.Pessoas
{
    public class Membro_Reconciliacao : Membro
    {        
        public int Data_reconciliacao { get; set; }

        public Membro_Reconciliacao() : base()
        {
        }

        internal string ReturnJson(Membro_Reconciliacao cri)
        {
            throw new NotImplementedException();
        }
    }
}
