'use strict';

/* globals Server, VirtualMachine, ServerCalculator */

describe('ServerCalculator spec', function () {
  describe('CanAddVirtualMachine', function () {
    establish(function () {
      this.calculator = new ServerCalculator();
      this.server = new Server(8, 32, 100);
    });

    describe('When the server has enough free capabilities', function () {
      establish(function () {
        this.virtualMachine = new VirtualMachine(4, 8, 100);
      });

      because(function () {
        this.canAdd = this.calculator.canAddVirtualMachine(this.server, this.virtualMachine);
      });

      it('Should return true', function () {
        expect(this.canAdd).toBe(true);
      });
    });

    describe('When the server has not enough free capabilities', function () {
      establish(function () {
        this.virtualMachine = new VirtualMachine(8, 64, 100);
      });

      because(function () {
        this.canAdd = this.calculator.canAddVirtualMachine(this.server, this.virtualMachine);
      });

      it('Should return false', function () {
        expect(this.canAdd).toBe(false);
      });
    });

    describe('When the server has already some virtual machines', function () {
      describe('and not enough space for the next virtual machine', function () {
        establish(function () {
          this.server.virtualMachines.push(new VirtualMachine(4, 16, 40));
          this.server.virtualMachines.push(new VirtualMachine(4, 16, 40));
          this.virtualMachine = new VirtualMachine(2, 8, 30);
        });

        because(function () {
          this.canAdd = this.calculator.canAddVirtualMachine(this.server, this.virtualMachine);
        });

        it('Should return false', function () {
          expect(this.canAdd).toBe(false);
        });
      });

      describe('and has enough space for the next virtual machine', function () {
        establish(function () {
          this.server.virtualMachines.push(new VirtualMachine(4, 16, 40));
          this.virtualMachine = new VirtualMachine(2, 8, 30);
        });

        because(function () {
          this.canAdd = this.calculator.canAddVirtualMachine(this.server, this.virtualMachine);
        });

        it('Should return true', function () {
          expect(this.canAdd).toBe(true);
        });
      });
    });
  });
});