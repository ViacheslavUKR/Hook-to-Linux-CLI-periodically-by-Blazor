using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SshHook1.Services
{
    public class CircuitHandlerService : CircuitHandler
    {
        public ConcurrentDictionary<string, Circuit> Circuits { get; set; }
        public event EventHandler CircuitsChanged;

        protected virtual void OnCircuitsChanged()
             => CircuitsChanged?.Invoke(this, EventArgs.Empty);

        public CircuitHandlerService()
        {
            Circuits = new ConcurrentDictionary<string, Circuit>();
        }

        //Invoked when a new circuit was established.
        public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            Circuits[circuit.Id] = circuit;
            OnCircuitsChanged();
            return base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }

        //Invoked when a new circuit is being discarded.
        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            Circuit circuitRemoved;
            Circuits.TryRemove(circuit.Id, out circuitRemoved);
            OnCircuitsChanged();
            return base.OnCircuitClosedAsync(circuit, cancellationToken);
        }

        //Invoked when a connection to the client was dropped.
        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnConnectionDownAsync(circuit, cancellationToken);
        }

        //Invoked when a connection to the client was established. - This method is executed once initially after OnCircuitOpenedAsync(Circuit, CancellationToken) and once each for each reconnect during the lifetime of a circuit.
        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            return base.OnConnectionUpAsync(circuit, cancellationToken);
        }
    }
}
