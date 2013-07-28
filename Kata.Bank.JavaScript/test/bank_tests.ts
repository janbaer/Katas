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
      account.should.have.property('credit');
      account.credit.should.be.eql(200);
    });

  });


});

