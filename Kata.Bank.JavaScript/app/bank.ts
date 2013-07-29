export function createAccount(owner: string) {
  return new Account(owner);
}

export function transfer(from: IAccount, to: IAccount,amount: number ) {
  if(amount > from.balance) {
    throw new Error('not enough credit on account1')
  }
  from.debit(amount);
  to.credit(amount);
}

export interface IAccount {
  owner: string;
  balance: number;

  credit(amount: number) : void;
  debit(amount: number) : void;
    }
export class Account implements IAccount {
  public owner: string;
  public balance: number;

  constructor(owner: string) {
    this.owner = owner;
    this.balance = 200;
  }

  public credit(amount: number) {
    this.balance += amount;
  }

  public debit(amount: number) {
    this.balance -= amount;
  }
}
