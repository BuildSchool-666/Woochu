
//聲明式渲染
const app = new Vue({
    el:'#app',
    //資料,state
    data:{
        //儲存註冊表單的資料
        signup:{
            account: '@Model?.Email',
            password:'@Model?.Password',
            checkPassword:'@Model?.PasswordConfirm'
        },
        //儲存表單驗證相關
        signupCheck:{
            accountError:false,
            accountErrorMsg:'',
            passwordError:false,
            passwordErrorMsg:'',
            checkPasswordError:false,
            checkPaswordErrorMsg:'',
        },
        //送出按鈕驗證
        addVerify: true
    },
    watch:{
        'signup.account':{
            immediate: true,
            handler: function(){
                if(this.signup.account =='')
                {
                    this.signupCheck.accountError = true
                    this.signupCheck.accountErrorMsg = '帳號不得為空'
                }
                else if(this.signup.account.length < 8 )
                {
                    this.signupCheck.accountError = true
                    this.signupCheck.accountErrorMsg = '帳號不得小於8碼'
                }
                else
                {
                    this.signupCheck.accountError = false
                    this.signupCheck.accountErrorMsg = ''
                }
                this.checkAddVerify()
            }
        },
        'signup.password':{
            immediate: true,
            handler: function()
            {
                this.signupCheck.checkPasswordError = false
                this.signupCheck.checkPaswordErrorMsg = ''

               
                this.checkAddVerify()
            }
        },
        'signup.checkPassword':{
            immediate: false,
            handler: function(){
                if(this.signup.checkPassword != this.signup.password)
                {
                    this.signupCheck.checkPasswordError = true
                    this.signupCheck.checkPasswordErrorMsg = '密碼與第一次輸入不吻合'
                }
                else
                {
                    this.signupCheck.checkPasswordError = false
                    this.signupCheck.checkPasswordErrorMsg = ''
                }
                this.checkAddVerify();
            }
        }
    },
    methods:{
        checkAddVerify(){
            for(let prop in this.signupCheck)
            {
                if(this.signupCheck[prop] == true)
                {
                    this.addVerify = true
                    return
                }
                this.addVerify = false;
                }
            }
        }   
    })
