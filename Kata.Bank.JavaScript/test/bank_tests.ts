///<reference path='../tsdefinitions/mocha.d.ts' />
///<reference path='../tsdefinitions/should.d.ts' />
///<reference path='../app/bank.ts' />


import should = require('should');
import bank = require('../app/bank');

describe('Bank test scenarios', function () {
  describe('When new account is created', function () {
    it('should create a the account with the given owner', function () {
      var account = bank.createAccount('Jan Baer');
      should.exist(account);
      account.should.have.property('owner');
      account.owner.should.be.eql('Jan Baer');
    });

    it('should give the owner as present 200 credit', function () {
      var account = bank.createAccount('Jan Baer');
      account.should.have.property('balance');
      account.balance.should.be.eql(200);
    });

    describe('when credit was called', function () {
      it('should add the amount to balance', function () {
        var account = bank.createAccount('Jan Baer');
        account.should.have.property('balance');
        account.credit(250);
        account.balance.should.be.eql(450);
      });
    });

    describe('when debit was called', function () {
      it('should remove the amount from the balance', function () {
        var account = bank.createAccount('Jan Baer');
        account.should.have.property('balance');
        account.debit(200);
        account.balance.should.be.eql(0);
      });
    });

    describe('when bank transfer money between accounts', function () {
      it('should debit the money from first account and credit the money to the second accound', function () {
        var account1 = bank.createAccount('Owner1');
        var account2 = bank.createAccount('Owner2');
        bank.transfer(account1, account2, 200);
        account1.balance.should.be.eql(0);
        account2.balance.should.be.eql(400)
      });

      describe('When on account1 has not enough money for the transfer', function () {
        it('should throw an exeption', function () {
          var account1 = bank.createAccount('Owner1');
          var account2 = bank.createAccount('Owner2');
          (function(){
            bank.transfer(account1, account2, 201);
          }).should.throw();

        });

      });
    });



  });


});

