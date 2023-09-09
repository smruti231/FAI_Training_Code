
// Create a JS class called Expense with attributr id, desc, date, amount, category
// Create JS called ExpenseManager that has one attribute called expenseArray
// The functions of the ExpenseManager will be CRUD operations : addExpense, updateExpense, getAllExpense, findExpenseByDate(date), fundExpenseByCategory(category)



class Expense{
    constructor(id, detail, date, amount, category){
    this.id = id;
    this.detail = detail;
    this.date = date;
    this.amount = amount;
    this.category = category;
    }
}

class ExpenseManager{
    expenses = [];

    getData(){
        if(localStorage.getItem("all") != undefined){
            this.expenses = JSON.parse(localStorage.getItem("all"));
            debugger;
        }
    }
    
    addNewExpense = (ex) => {
        this.getData();
        this.expenses.push(ex);
        localStorage.setItem("all",JSON.stringify(this.expenses));
    }
    
    getAllExpenses = () => {this.getData(); return this.expenses};

    updateExpense = (id,ex) =>{
        const index = this.expenses.findIndex((e) => e.id == id);
        if(index == -1){
            throw "Expense not found to Update";
        }
        this.expenses.splice(index,1,ex);
        localStorage.setItem("all", JSON.stringify(this.expenses));
    }

    getStringDate(dt){
        return `${dt.getDate()}/${dt.getMonth()+1}/${dt.getFullYear()}`;
    }
    findExpenseByDate = (dt) => {
        this.getData();
        return this.expenses.filter((s) => this.getStringDate(dt) == this.getStringDate(new Date(s.date)));
    }


    findExpenseByCategory = (cat) => {
        this.getData();
        return this.expenses.filter((d) => d.category == cat);
    }

    deleteExpense = (id) => {
        const index = this.expenses.findIndex((e) => e.id == id);
        if(index != -1){
            this.expenses.splice(index,1);
            localStorage.setItem("all", JSON.stringify(this.expenses))
        }
    }
}