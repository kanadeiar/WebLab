import { TextBox } from './components/text-box.js'

const firstapp = Vue.createApp({
    components: {
        'text-box' : TextBox
    },
    data() {
        return {
            message: 'нажмите кнопку'
        }
    },
    methods: {
        setMessage() {
            this.message = 'Новое сообщение приветственное!';
        }
    }
});

firstapp.mount("#firstapp")