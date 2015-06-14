'use strict';

class Server {
  constructor(cpu, memory, network) {
    this.cpu = cpu;
    this.memory = memory;
    this.network = network;
    this.virtualMachines = [];
  }
}

class VirtualMachine {
  constructor(cpu, memory, network) {
    this.cpu = cpu;
    this.memory = memory;
    this.network = network;
  }
}

class ServerCalculator {
  measureSumOf(server, property) {
    var sum = 0;

    server.virtualMachines.forEach(vm => {
      sum += vm[property];
    });

    return sum;
  }

  verifyCapability(server, virtualMachine, property) {
    return server[property] >= this.measureSumOf(server, property) + virtualMachine[property];
  }

  canAddVirtualMachine(server, virtualMachine) {
    return this.verifyCapability(server, virtualMachine, 'cpu') &&
           this.verifyCapability(server, virtualMachine, 'memory') &&
           this.verifyCapability(server, virtualMachine, 'network');
  }
}