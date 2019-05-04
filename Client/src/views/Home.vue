<template>
  <div class="home">
    <h1>Todo list</h1>
    <div>List is {{this.text}}</div>
    <ToDoList v-on:send="sendText">
      No content.
    </ToDoList>
  </div>
</template>

<script lang="ts">
  import { Component, Vue } from "vue-property-decorator";
  import ToDoList from "@/components/toDo/ToDoList.vue";

  @Component({
  components: {
    ToDoList
  }
  })
  export default class Home extends Vue {

    public text: string = "not sorted.";

    sendText(inputText) {
      this.text = inputText;
    }

  }
</script>
