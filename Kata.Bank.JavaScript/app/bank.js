function createAccount(owner) {
    return new Account(owner);
}
exports.createAccount = createAccount;

function transfer(from, to, amount) {
    if (amount > from.balance) {
        throw new Error('not enough credit on account1');
    }
    from.debit(amount);
    to.credit(amount);
}
exports.transfer = transfer;

var Account = (function () {
    function Account(owner) {
        this.owner = owner;
        this.balance = 200;
    }
    Account.prototype.credit = function (amount) {
        this.balance += amount;
    };

    Account.prototype.debit = function (amount) {
        this.balance -= amount;
    };
    return Account;
})();
exports.Account = Account;

//@ sourceMappingURL=bank.js.map
