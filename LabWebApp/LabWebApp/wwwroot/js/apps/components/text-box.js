export const TextBox = {
    data() {
        return {
            text: 'text'
        };
    },
    template: `
    <div>
        <p>Введенный текст: {{ text }}</p>
        <input v-model="text" type="text" class="form-control" /> 
    </div>
    `
}