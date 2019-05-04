<template>
  <div>
    <div>
      <button @click="sortList($event)">Sort</button>
    </div>
    <div>
      <label>Filter: </label>
      <button @click="filterAll($event)">All</button>
      <button @click="filterComplete($event)">Complete</button>
      <button @click="filterIncomplete($event)">Incomplete</button>
    </div>
   

    <div v-if="this.checkedFilterState == 0">
      <div v-if="allToDos" v-for="toDo in allToDos">
        <input type="checkbox" v-model="toDo.check" @change="checkChange($event, toDo)" /> {{toDo.name}}
      </div>
      <div v-if="allToDos.length < 1">
        <slot></slot>
      </div>
    </div>

    <div v-if="this.checkedFilterState == 1">
      <div v-if="checkedToDos" v-for="toDo in checkedToDos">
        <input type="checkbox" v-model="toDo.check" @change="checkChange($event, toDo)" /> {{toDo.name}}
      </div>
      <div v-if="checkedToDos.length < 1">
        <slot></slot>
      </div>
    </div>
    
    <div v-if="this.checkedFilterState == 2">
      <div v-if="unCheckedToDos" v-for="toDo in unCheckedToDos">
        <input type="checkbox" v-model="toDo.check" @change="checkChange($event, toDo)" /> {{toDo.name}}
      </div>
      <div v-if="unCheckedToDos.length < 1">
        <slot></slot>
      </div>
    </div>
  
  </div>
</template>

<script lang="ts">
  import { Component, Prop, Vue } from "vue-property-decorator";
  import store from '@/store/index.ts';

  export default {
    data() {
    return{
      isDescendingSort: false,
        checkedFilterState: 0
      }
    },

    computed: {
      allToDos() {
        return store.getters.allToDos;
      },
      unCheckedToDos()  {
        return store.getters.unCheckedToDos;
      },
      checkedToDos()  {
        return store.getters.checkedToDos;
      }
    },

    created() {
      store.dispatch('fetchToDos');
    },

    methods:{
      sortList(e: any) {
        store.dispatch('fetchSortToDos', this.isDescendingSort);
        this.isDescendingSort = !this.isDescendingSort;
        this.$emit('send', 'sorted.');
      },
      checkChange(e: any, item: ToDo) {
        this.$http.put('http://localhost:8000/api/todo/' + item.id, item.check).then(
        response => {
        }, 
        error => {
          console.log("ERROR: ", error);
        });
    },
    filterAll(e: any) {
      this.checkedFilterState = 0;
      },
    filterComplete(e: any) {
      this.checkedFilterState = 1;
    },
    filterIncomplete(e: any) {
      this.checkedFilterState = 2;
    },

    }
  }

</script>

<style scoped lang="scss">
  button {
    margin-right: 5px;
    margin-bottom: 5px;
    border-radius: 3px;
  }
</style>
