const LoanCalculator=()=>{
     return (period,years)=>{
        let RateOfIntrest = prompt("Please Enter Rate Of Intrest");
        return period*years*RateOfIntrest;
    }
}
const carLoanCalculator=LoanCalculator();
carLoanCalculator(12,5);
const homeLoanCalculator=LoanCalculator(takeRateOFIntrest());
homeLoanCalculator(10,15);
const personalLoanCalculator=LoanCalculator(takeRateOFIntrest());
personalLoanCalculator(12,2);



currentValue=0;
var increment = function(step) {

    currentValue += step;
    console.log('currentValue = ' + currentValue);
}
console.log(increment(10));