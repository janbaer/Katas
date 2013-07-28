function createAccount(owner) {
    return new Account(owner);
}
exports.createAccount = createAccount;

var Account = (function () {
    function Account(owner) {
        this.owner = owner;
        this.credit = 200;
    }
    return Account;
})();
exports.Account = Account;

//@ sourceMappingURL=bank.js.map
