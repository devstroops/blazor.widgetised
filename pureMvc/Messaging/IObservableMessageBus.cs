﻿using System;

namespace Blazor.PureMvc.Messaging
{
    public interface IMessageBusRegister
    {
        void Register<TMessage>(object receiver, Action<TMessage> handler)
            where TMessage : IMessage;

        void Unregister<TMessage>(object receiver);

        void UnregisterAll(object receiver);
    }
}
