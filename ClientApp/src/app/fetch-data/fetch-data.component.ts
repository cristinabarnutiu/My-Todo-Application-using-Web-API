import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public todoItems: TodoItem[];

    public name: string = "test";
    //public title: string = "test"; 

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.loadTodoItems();
    }

    loadTodoItems() {

    this.http.get<TodoItem[]>(this.baseUrl + 'api/todoitems').subscribe(result => {
          this.todoItems = result;
          console.log(this.todoItems);
      }, error => console.error(error));
    }

    delete(todoItemId: string) {
        if (confirm('Are you sure you want to delete the item with id' + todoItemId + '?')) {
            this.http.delete(this.baseUrl + 'api/todoitems/' + todoItemId).subscribe(
                result => {
                alert('Todo Item successfully deleted!');
                this.loadTodoItems();
            },
                error => alert('Cannot delete item. Please check if it has comments.'))
        }
    }

    submit() {
        var todoItem: TodoItem = <TodoItem>{};
        todoItem.title = this.name;
        todoItem.description = this.name;
        todoItem.dateAdded = null;
        todoItem.deadline = null;
        todoItem.importance = Importance.Low;
        todoItem.state = State.Open;
        todoItem.dateClosed = null;

        this.http.post(this.baseUrl + 'api/todoitems', todoItem).subscribe(result => {
            console.log('succes!');
            this.loadTodoItems();
        },
            error => {
                if (error.status == 400) {
                    console.log(error.errror.errors)
                }
            });
    }
}

interface TodoItem {
    id: number;
    title: string;
    description: string;
    dateAdded: Date;
    deadline: Date;
    importance: Importance;
    state: State;
    dateClosed: Date;
}

enum Importance { Low =0, Medium=1, High=2 }
enum State { Open=0, InProgress=1, Closed=2 }
