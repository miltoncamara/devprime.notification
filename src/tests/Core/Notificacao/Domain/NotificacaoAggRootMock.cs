using System;
using System.Collections.Generic;
using DevPrime.Stack.Test;

namespace Tests_Domain.Notificacao
{
    public partial class NotificacaoAggRootTest
    {
        public Domain.Aggregates.Notificacao.Notificacao MockNotificacao()
        {
            var agg = new Domain.Aggregates.Notificacao.Notificacao(
                       String.Empty,
                       String.Empty,
                       String.Empty,
                       null,
                       Guid.Empty

             );

            agg.Dp = new DpDomainMock(null);
            agg.DevPrimeSetProperty<String>("Nome", Faker.Lorem.Sentence());
            agg.DevPrimeSetProperty<String>("Email", Faker.Lorem.Sentence());
            agg.DevPrimeSetProperty<String>("Telefone", Faker.Lorem.Sentence());
            agg.DevPrimeSetProperty<Guid>("ID", Guid.NewGuid());
        
            agg.Dp.Source = agg;
            return agg;
        }
    }
}